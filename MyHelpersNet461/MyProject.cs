namespace Mobilize.Helpers
{



	public partial class MyProject
	{

		public MyForms MyForms { get; set; } = new MyForms();

		public MyComputer Computer { get; set; } = new MyComputer();

		public MyWebServices WebServices { get; set; } = new MyWebServices();
	}

	public static class MyHelpers
    {
		public static MyProject MyProject { get; set; } = new MyProject();
    }

}