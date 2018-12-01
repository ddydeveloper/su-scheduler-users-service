namespace SuSchedulerUsers.Sql
{
    public static class GetRequests
    {
        public static string GetUsers = @"
SELECT *
FROM Users U 
    INNER JOIN Companies C ON U.CompanyId = C.Id
    INNER JOIN Positions P ON U.PositionId = P.Id
WHERE U.Id = @UserId
";

        public static string GetUser = $@"{GetUsers} WHERE U.Id = @UserId";

        public static string GetCompanyUsers = $@"{GetUsers} WHERE U.CompanyId = @CompanyId";
    }
}
