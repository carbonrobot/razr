namespace Razr.Web.Components.Markdown
{
	public interface IContentProvider
	{
		string GetContent(string docId);
	}
}