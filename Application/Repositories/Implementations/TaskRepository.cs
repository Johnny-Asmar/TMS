using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.Repositories.Abstraction;
using Application.ViewModel;
using Domain.Models;
using MediatR;
using Persistence.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private Context _dbContext;
        public TaskRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public ApiResponse<string> AddTask(AddTaskCommand task)
        {
            try
            {
                Domain.Models.Task taskCreate = new Domain.Models.Task()
                {
                    Title = task.title,
                    Description = task.description,
                    AssignedTo = task.userId,
                    EndDate = task.endDate,
                    Status = task.status,
                };
                _dbContext.Tasks.Add(taskCreate);
                _dbContext.SaveChanges();
                return new ApiResponse<string>(1, "Add Done", "Done", "");
            }
            catch (Exception ex) {
                return new ApiResponse<string>(-1, "Save Add Issue", "Not Done", ex.ToString());
            }
            }
        public ApiResponse<string> DeleteTask(int taskId)
        {
            var task = GetTaskById(taskId);
            if (task.Id == -1) { return new ApiResponse<string>(-1, "Task NOT FOUND", "Not Found", ""); }
            try
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
                return new ApiResponse<string>(1, "Task DELETED", "Deleted", "");

            }catch(Exception ex)
            {
                return new ApiResponse<string>(-1, "Save Delete Issue", "Not Done", ex.ToString());
            }
        }
        public ApiResponse<string> UpdateTask(UpdateTaskCommand task)
        {
            var taskFind = GetTaskById(task.id);
            if (taskFind.Id == -1) { return new ApiResponse<string>(-1, "Task NOT FOUND", "Not Done", "NOT FOUND"); }
            // If exists, update Task
            try
            {
                taskFind.Title = task.title;
                taskFind.Description = task.description;
                taskFind.AssignedTo = task.userId;
                taskFind.EndDate = task.endDate;
                taskFind.Status = task.status;
                _dbContext.Tasks.Update(taskFind);
                _dbContext.SaveChanges();
                return new ApiResponse<string>(1, "Update Task SUCCEDED", "Done", "");
            }catch(Exception ex)
            {
                return new ApiResponse<string>(-1, "Save Update Issue", "Not Done", ex.ToString());
            }
        }
        public Domain.Models.Task GetTaskById(int taskId)
        {
           var task = _dbContext.Tasks.ToList().FirstOrDefault(t => t.Id == taskId,
           new Domain.Models.Task
           {
               Id = -1,
               Title = "NOT FOUND"
           });
            return task;
        }
        public ApiResponse<GetTasksDTO> GetTaskDTOById(int taskId)
        {
            var Fetchedtask = _dbContext.Tasks.ToList().FirstOrDefault(t => t.Id == taskId, new Domain.Models.Task { Id = -1, Title = "NOT FOUND" });
            GetTasksDTO t = new GetTasksDTO
            {
                Id = Fetchedtask.Id,
                Title = Fetchedtask.Title,
                Description = Fetchedtask.Description,
                AssignedTo = Fetchedtask.AssignedTo,
                EndDate = Fetchedtask.EndDate,
                Status = Fetchedtask.Status,
            };
            return new ApiResponse<GetTasksDTO>(1, "Get Task By Id", t, "");
        }
        public ApiResponse<List<GetTasksWithUserNameDTO>> GetTasksWithUserName()
        {
            try
            {
                var tasks = (from taskTable in _dbContext.Tasks
                             join userTable in _dbContext.Users on taskTable.AssignedTo equals userTable.Id
                             select new GetTasksWithUserNameDTO
                             {
                                 Id = taskTable.Id,
                                 Description = taskTable.Description,
                                 Status = taskTable.Status,
                                 EndDate = taskTable.EndDate,
                                 Title = taskTable.Title,
                                 Name = userTable.Name
                             }).ToList();

                return new ApiResponse<List<GetTasksWithUserNameDTO>>(1, "Get Tasks with the user name", tasks, "");
            }catch(Exception ex)
            {
                return new ApiResponse<List<GetTasksWithUserNameDTO>>(-1, "Get Data Issue", new List<GetTasksWithUserNameDTO>(), ex.ToString());
            }

        }

    }
}
