using Xunit;
using Packt;
using System;

namespace isPrimeUnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        int a = 1;
        var test = new PrimeOperations();
        //Act
        //Assert
        Assert.False(test.isPrime(a));
    }
    [Fact]
    public void Test8()
    {
        //Arrange
        int a = 8;
        var test = new PrimeOperations();
        //Act
        //Assert
        Assert.False(test.isPrime(a));   
    }
    [Fact]
    public void Test13()
    {
        //Arrange
        int a = 13;
        var test = new PrimeOperations();
        //Act
        //Assert
        Assert.True(test.isPrime(a));
    }
    [Fact]
    public void Test2()
    {
        //Arrange
        int a = 2;
        var test = new PrimeOperations();
        //Act
        //Assert
        Assert.True(test.isPrime(a));
    }
}