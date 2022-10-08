using Xunit;
using Packt;
using System;

namespace PrimeFactorsUnitTest;

public class PrimeFactorUnitTest
{
    [Fact]
    public void TestFor10()
    {
        //arrange
        int a = 10;
        string expected = " 2 5";
        var operation = new PrimeOperations();
        //act
        string actual = operation.PrimeFactors(a);
        //assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestFor250()
    {
        //arrange
        int a = 250;
        string expected = " 2 5 5 5";
        var operation = new PrimeOperations();
        //act
        string actual = operation.PrimeFactors(a);
        //assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestFor37()
    {
        //arrange
        int a = 37;
        string expected = " 37";
        var operation = new PrimeOperations();
        //act
        string actual = operation.PrimeFactors(a);
        //assert
        Assert.Equal(expected, actual);
    }
}