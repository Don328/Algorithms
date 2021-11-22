using Xunit;
using NumberGenerator.Services;
using System;
using System.Collections.Generic;

public class ListMaker_Tests
{
    [Fact]
    public void ParseArgs_TestEmpty_CountShouldBeSameAsDefault()
    {
        var args = new string[] { };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.count == ListMaker.countDefault);
    }

    [Fact]
    public void ParseArgs_TestNotNumbers_CountShouldBeSameAsDefault()
    {
        var args = new string[] { "str1", "str2" };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.count == ListMaker.countDefault);
    }

    [Fact]
    public void ParseArgs_TestValues_CountShouldBeSetToInputValue()
    {
        var rand = new Random();
        var inputCount = rand.Next(50);
        var args = new string[] { $"{inputCount}", "100" };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.count == inputCount);
    }

    [Fact]
    public void ParseArgs_TestEmpty_BoundsShouldBeSameAsDefault()
    {
        var args = new string[] { };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.upperBounds == ListMaker.upperBoundsDefault);
    }

    [Fact]
    public void ParseArgs_TestNotNumbers_BoundsShouldBeSameAsDefault()
    {
        var args = new string[] { "str1", "str2" };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.upperBounds == ListMaker.upperBoundsDefault);
    }


    [Fact]
    public void ParseArgs_TestValues_BoundsShouldBeSetToInputValue()
    {
        var rand = new Random();
        var inputBounds = rand.Next(10, 100);
        var args = new string[] { "10", $"{inputBounds}" };
        ListMaker.ParseArgs(args);
        Assert.True(ListMaker.upperBounds == inputBounds);
    }

    [Fact]
    public void CrateNumsList_Test()
    {
        var rand = new Random();
        var testCount = rand.Next(10, 50);
        ListMaker.count = testCount;
        ListMaker.upperBounds = 100;
        ListMaker.CreateNumsList();

        Assert.True(ListMaker.nums.Count == testCount);
    }

    [Fact]
    public void CreteNumString_Test()
    {
        ListMaker.nums = new List<int>
        { 5, 18, 23, 25, 38, 41, 42, 57, 64, 71, 92 };
        var testString = "5 18 23 25 38 41 42 57 64 71 92 ";
        
        var result = ListMaker.CreateNumString();

        Assert.True(string.Compare(result, testString) == 0);
    }
}