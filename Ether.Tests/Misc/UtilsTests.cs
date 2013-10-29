using System.IO;
using Codestellation.Ether.Misc;
using NUnit.Framework;

namespace Codestellation.Ether.Tests.Misc
{
    [TestFixture]
    public class UtilsTests
    {
        [Test]
        public void MakeRootedPath_should_make_rooted_path()
        {
            string path = Utils.MakeRootedPath("Resources");
            Assert.That(Path.IsPathRooted(path), Is.True);
        }
    }
}