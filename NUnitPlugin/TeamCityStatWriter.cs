namespace NUnitPlugin
{
	using System.Globalization;
	using System.IO;
	using System.Xml;

	using JetBrains.TeamCity.ServiceMessages.Write.Special;

	using NUnit.Engine.Extensibility;

	[Extension]
	[ExtensionProperty("Format", "TeamCityStat")]
	public class TeamCityStatWriter : IResultWriter
	{
		private static readonly ITeamCityWriter TeamCityWriter = new TeamCityServiceMessages().CreateWriter();

		public void CheckWritability(string outputPath)
		{			
		}

		public void WriteResultFile(XmlNode resultNode, string outputPath)
		{
			var durationAttr = resultNode.Attributes?["duration"];
			if (durationAttr?.Value == null)
			{
				return;
			}

			double durationValue;
			if (!double.TryParse(durationAttr.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out durationValue))
			{
				return;
			}

			TeamCityWriter.WriteBuildStatistics("TestsDuration", durationValue.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteResultFile(XmlNode resultNode, TextWriter writer)
		{		
		}
	}
}
