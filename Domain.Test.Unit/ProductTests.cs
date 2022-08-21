using Domain.Shared;
using Domain.Shared.Exceptions;
using Domain.Test.Unit.Builders;
using FluentAssertions;

namespace Domain.Test.Unit
{
    public class ProductTests
    {
        private ProductBuilder _productBuilder;
        public ProductTests()
        {
            _productBuilder=new ProductBuilder();
        }
        [Fact]
        public void Constructor_Should_Create_Product_When_Data_Is_Ok()
        {
            //arrange
            _productBuilder.SetTitle("test2").SetMoney(1000);
            //act
            var product = _productBuilder.Build();

            //asserts
            product.Title.Should().Be("test2");
        }

        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_Title_Is_Null()
        {
            //act
            var action = new Action(() =>
            {
                _productBuilder.SetTitle("").Build();
            });
            //asserts
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>()
                .WithMessage("title is null or empty");
        }
        [Fact]
        public void Edit_Should_Update_When_Data_Is_Ok()
        {
            //arrange
            var product= _productBuilder.SetTitle("test2").SetMoney(1000).Build();
            //act
            product.Edit("edited",new Money(1000000));
            //asserts
            product.Title.Should().Be("edited");
            product.Money.Value.Should().Be(1000000);
        }

        [Fact]
        public void Edit_Should_Throw_NullOrEmptyException_When_Title_Is_Null()
        {
            //arrange
            var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();
            //act
            var action = () =>
            {
                product.Edit("", new Money(1000000));
            };
            //asserts
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>()
                .WithMessage("title is null or empty");
        }
        [Fact]
        public void AddImage_Should_Add_New_Image_To_Product()
        {
            //arrange
            var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();
            //act
            product.AddImages("test.png");
            //asserts
            product.Images.Should().HaveCount(1);
        }
        [Fact]
        public void RemoveImage_Should_Remove_Image_When_Image_Is_Exist()
        {
            //arrange
            var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();
            product.AddImages("test.png");
            //act
            product.RemoveImages(0);
            //asserts
            product.Images.Should().HaveCount(0);
        }
        [Fact]
        public void RemoveImage_Should_Throw_NullOrEmptyException_When_Image_Is_Not_Exist()
        {
            //arrange
            var product = _productBuilder.SetTitle("test2").SetMoney(1000).Build();
            //act
            var action=()=> product.RemoveImages(0);
            //asserts
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>()
                .WithMessage("Image not found");
        }

    }
}