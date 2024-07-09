namespace AppoinmentServices.Enum
{
    public enum APIResponseStatus
    {
        Success = 200,
        Error = 400,
        Failure = 409, //conflict
        NotFound = 404,
        Created = 201,
        NoContent = 204,
        UnAuthorized = 401
        //Forbidden = 403

    }
}
