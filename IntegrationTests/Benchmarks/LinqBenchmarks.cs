namespace IntegrationTests;

using System.Linq;

public class LinqBenchmarks
{
  [Fact]
  public void LinqStatementTimeComplexityBenchmarkTest()
  {
    // Arrange
    var iterationCount = 0;
    var collection = new List<int> { 1, 2, 3, 4, 5 };
    var expectedIterationComplexity = collection.Count;

    var monitoredCollection = collection.Select(element =>
    {
      // The counter will increment each time an element is accessed
      iterationCount++;
      return element;
    });

    // Act
    var result = monitoredCollection
      .Where(x => x > 2)
      .Where(x => x % 2 == 0)
      .Where(x  => x > 3)
      .ToList();

    // Assert
    result.Should().NotBeEmpty();
    iterationCount.Should().Be(expectedIterationComplexity);
  }
}