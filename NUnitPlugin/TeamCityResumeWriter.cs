namespace NUnitPlugin
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Xml;

	using JetBrains.TeamCity.ServiceMessages.Write.Special;

	using NUnit.Engine.Extensibility;

	[Extension]
	[ExtensionProperty("Format", "TeamCityResume")]
	public class TeamCityResumeWriter : IResultWriter
	{
		private static readonly ITeamCityWriter TeamCityWriter = new TeamCityServiceMessages().CreateWriter();

		public void CheckWritability(string outputPath)
		{			
		}

		public void WriteResultFile(XmlNode resultNode, string outputPath)
		{
			if (resultNode.Attributes == null)
			{
				return;
			}

			var num = 0;
			var stat =
				from attr in resultNode.Attributes.Cast<XmlAttribute>()
				where !StringComparer.InvariantCultureIgnoreCase.Equals(attr.Name, "id")
				where int.TryParse(attr.Value, out num)
				select new { name = attr.Name, val = num };
			
			foreach (var item in stat)
			{
				TeamCityWriter.WriteMessage($"{item.name}: {item.val}");
			}			
		}

		public void WriteResultFile(XmlNode resultNode, TextWriter writer)
		{		
		}
	}
}
