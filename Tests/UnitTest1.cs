namespace Tests
{
	using System;
	using System.Configuration;

	using NUnit.Framework;

	[TestFixture]
    public class UnitTest1
    {
		[Test]
		[Category("Sample1")]
		[Category("Sample2")]
		[Category("Sample3")]
		public void TestMethod1()
        {
			Console.Write("Success !!!");
        }		

		[Test]
		[Category("Sample4")]
		public void TestMethod2()
		{
			var message = ConfigurationManager.AppSettings["message"];
			Assert.NotNull(message);
			Console.Write(message);
		}
	}
}