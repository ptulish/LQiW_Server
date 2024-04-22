namespace LQiW_Server.Classen;

public class MessageFromClient
{
    public string Address { get; set; }
    public string UserGroup { get; set; }
    public string Street { get; private set; }
    public int HouseNumber { get; private set; }

    public void ParseAddress()
    {
        var match = System.Text.RegularExpressions.Regex.Match(Address, @"^(.*[^\d])(\d+)$");
        if (match.Success)
        {
            Street = match.Groups[1].Value.Trim();
            HouseNumber = int.Parse(match.Groups[2].Value);
        }
        else
        {
            Street = Address.Trim();
            HouseNumber = 0;
        }
    }
}