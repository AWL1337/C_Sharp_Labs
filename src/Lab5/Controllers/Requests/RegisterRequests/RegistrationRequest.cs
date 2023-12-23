namespace Controllers.Requests.RegisterRequests;

public record RegistrationRequest(int Id, string Password) : RegisterRequest;