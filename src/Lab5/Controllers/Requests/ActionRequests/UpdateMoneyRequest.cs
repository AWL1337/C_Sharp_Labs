namespace Controllers.Requests.ActionRequests;

public record UpdateMoneyRequest(int Id, int Diff) : ActionRequest;