namespace Controllers.Requests.ActionRequests;

public record CreateNewUserRequest(int Id, string Password) : ActionRequest;