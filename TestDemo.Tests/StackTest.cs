namespace Stack.Tests;
public class StackTest
{
    IStack<int> stackUT;
    public StackTest()
    {
        stackUT = new LinkedStack<int>();
    }
    [Fact]
    public void NewStackShouldBeEmpty()
    {
        Assert.True(stackUT.IsEmpty);
    }

    [Fact]
    public void PushPopShouldReturnSameItem()
    {
        // setup
        int expected = 1;

        // execute system under test
        stackUT.Push(expected);

        // validate results
        Assert.Equal(expected, stackUT.Pop());
        Assert.True(stackUT.IsEmpty);
    }
    [Fact]
    public void PeekIsNonDestructive()
    {
        int expected = 1;
        stackUT.Push(expected);
        Assert.Equal(expected, stackUT.Peek());
        Assert.False(stackUT.IsEmpty);
    }

    [Fact]
    public void StackIsFILO()
    {
        int first = 1;
        int second = 2;
        stackUT.Push(first);
        stackUT.Push(second);
        Assert.Equal(second, stackUT.Pop());
        Assert.Equal(first, stackUT.Pop());
        Assert.True(stackUT.IsEmpty);
    }

    [Fact]
    public void PopOnEmptyIsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => stackUT.Pop());
        Assert.Contains("empty", ex.Message);
    }

    [Fact]
    public void PeekOnEmptyIsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => stackUT.Pop());
        Assert.Contains("empty", ex.Message);
    }
}
