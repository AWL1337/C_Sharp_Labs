namespace Controllers.Requests.RegisterRequests;

public record LoginRequest(int Id, string Password) : RegisterRequest;