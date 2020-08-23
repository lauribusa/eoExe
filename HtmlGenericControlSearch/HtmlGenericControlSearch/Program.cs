using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace HtmlGenericControlSearch
{
	class Program
	{
		static void Main(string[] args)
		{

			HtmlGenericControl div = CreateMenuList("one", "two", "three", "four", "five");

			HtmlGenericControl searchResult = SearchHtmlControl(div, "name", "a_three");

			if(searchResult != null)
				Console.WriteLine("Found : " + searchResult.Attributes["name"].ToString());
			else
				Console.WriteLine("No result found.");
			
			Console.ReadKey();

		}
		static HtmlGenericControl CreateHtmlGenericControl(string tag, string name)
		{
			HtmlGenericControl tempCtrl = new HtmlGenericControl(tag);
			tempCtrl.Attributes.Add("name", name);
			return tempCtrl;
		}
		
		static HtmlGenericControl CreateMenuList(params string[] args)
		{
			HtmlGenericControl mainDiv = CreateHtmlGenericControl("div", "mainDiv");
			
			HtmlGenericControl ul = AddToControls(mainDiv, CreateHtmlGenericControl("ul", "ul"));

			for (int i = 0; i < args.Length; i++)
			{
				HtmlGenericControl tempLi = AddToControls(ul, CreateHtmlGenericControl("li", args[i]));
				AddToControls(tempLi, CreateHtmlGenericControl("a","a_"+args[i])); 
			}

			return mainDiv;
		}

		static HtmlGenericControl AddToControls(HtmlGenericControl parent, HtmlGenericControl child)
		{
			parent.Controls.Add(child);
			return child;
		}

		static HtmlGenericControl SearchHtmlControl(HtmlGenericControl root, string key, string value)
		{

			Console.WriteLine("Searching..." + root.Attributes[key].ToString());

			if ((root.Attributes[key].ToString() == value))
			{
				return root;
			}

			if (root.Controls == null)
			{
				return null;
			}
			
			for (int i = 0; i < root.Controls.Count; i++)
			{

				HtmlGenericControl current = (HtmlGenericControl)root.Controls[i];

				if (current.Attributes[key].ToString() == value)
				{

					return current;

				} else
				{

					HtmlGenericControl child = SearchHtmlControl(current, key, value);

					if (child != null)
					{

						return child;
					}
				}
			}
			return null;
		}
	}
}
