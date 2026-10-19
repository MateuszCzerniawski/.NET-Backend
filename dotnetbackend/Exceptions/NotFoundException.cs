namespace dotnetbackend.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
}