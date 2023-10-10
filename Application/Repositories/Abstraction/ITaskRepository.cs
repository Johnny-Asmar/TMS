using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Domain.Models.Task;

namespace Application.Repositories.Abstraction
{
    public interface ITaskRepository
    {
        public ApiResponse<string> AddTask(AddTaskCommand task);
        public ApiResponse<string> DeleteTask(int taskId);
        public ApiResponse<string> UpdateTask(UpdateTaskCommand task);
        public Task GetTaskById(int taskId);
        public ApiResponse<GetTasksDTO> GetTaskDTOById(int taskId);
        public ApiResponse<List<GetTasksWithUserNameDTO>> GetTasksWithUserName();
    }
}
