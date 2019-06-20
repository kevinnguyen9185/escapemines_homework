using System.IO;
using Application.Utilities;
using Xunit;

namespace Application.UnitTests.Utilities
{
    public class IntegerToPositiveIntergerCheckExtensionTests
    {
        [Fact]
        public void ToPositiveInteger_ShouldReturnError()
        {
            Assert.Throws<InvalidDataException>(() => IntegerToPositiveIntergerCheckExtension.ToPositiveInteger(-1));
        }
    }
}