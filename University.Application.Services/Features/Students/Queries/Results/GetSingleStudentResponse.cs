namespace University.Application.Layer.Features.Students.Queries.Results
{
    public record GetSingleStudentResponse
    {
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}