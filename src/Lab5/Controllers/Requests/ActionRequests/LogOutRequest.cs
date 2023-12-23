namespace Controllers.Requests.ActionRequests;

public record LogOutRequest(bool Agree) : ActionRequest;