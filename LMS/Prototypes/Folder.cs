namespace LMS.Prototypes;

public class Folder
{
	private readonly int _id;
	private string _name;

	public Folder(int id, string name)
	{
		_id = id;
		_name = name;
	}
}