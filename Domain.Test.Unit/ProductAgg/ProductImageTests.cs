using Domain.ProductAgg;
using Domain.Shared.Exceptions;
using FluentAssertions;

namespace Domain.Test.Unit.ProductAgg;

public class ProductImageTests
{
    [Fact]
    public void Should_Create_New_ProductImage_When_data_Is_Ok()
    {
        //arrange
        var productImage = new ProductImage(1, "test.png");

        //assert
        productImage.ImageName.Should().Be("test.png");
    }
    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyDomainDataException_when_ImageName_Is_Null()
    {
        //arrange
        var result =()=> new ProductImage(1, "");

        //assert
        result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("ImageName is null or empty");
    }
}