using DCAExamples.Core.Application.Common.CommandHandler;
using DCAExamples.Core.Application.UseCases.ProjectTasks.UpdateRemainingEstimate;
using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Entities;
using DCAExamples.Core.Domain.Aggregates.ProjectTaskAggregate.Values;
using DCAExamples.Core.Domain.Common.OperationResult;
using DCAExamples.Core.Domain.Common.Repositories;

namespace DCAExamples.Tests.UseCases.ProjectTaskTests.UpdateRemainingEstimate;

public class UpdateRemainingEstimateHandlerTest
{
    [Fact]
    public async Task CanUpdateTaskWithValidRemainingEstimate()
    {
        // Arrange
        TaskId taskId = TaskId.Create(Guid.NewGuid()).Value;
        ProjectTask task = CreateTestTask(taskId);
        TaskRepositoryMock repo = CreateHandler(task, out var handler);

        // act

        UpdateRemainingTaskEstimateCommand command = CreateCommand(taskId);
        Result handledResult = await handler.HandleAsync(command);
        
        // assert
        ProjectTask updatedTask = await repo.FindAsync(taskId);
        Assert.True(handledResult.IsSuccess);
        Assert.Equal(command.RemainingEstimate, updatedTask.Estimate);
    }

    private static UpdateRemainingTaskEstimateCommand CreateCommand(TaskId taskId)
    {
        int newEstimate = 25;
        UpdateRemainingTaskEstimateCommand command
            = UpdateRemainingTaskEstimateCommand.Create(taskId.Value, newEstimate).Value;
        return command;
    }

    private static TaskRepositoryMock CreateHandler(ProjectTask task, out ICommandHandler<UpdateRemainingTaskEstimateCommand> handler)
    {
        TaskRepositoryMock repo = new TaskRepositoryMock();
        repo.Aggregate = task;

        IUnitOfWork uow = new DummyUoW();

        handler = new UpdateRemainingTaskEstimateHandler(repo, uow);
        return repo;
    }

    private static ProjectTask CreateTestTask(TaskId taskId)
    {
        Estimate estimateValue = Estimate.Create(42).Value;
        ProjectTask task = ProjectTask.Create(taskId, estimateValue);
        return task;
    }
}

public class DummyUoW : IUnitOfWork
{
    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}

public class TaskRepositoryMock : IProjectTaskRepository
{
    public Task<ProjectTask> FindAsync(TaskId commandTaskId)
    {
        throw new NotImplementedException();
    }

    public ProjectTask Aggregate { get; set; }
}