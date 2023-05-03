using Vee_Tailoring.Emails;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;
using Vee_Tailoring.Models.DTOs;

namespace Vee_Tailoring.Implementations.Services;

public class OrderService : IOrderService
{
    IOrderRepo _repository;
    IStyleRepo _stylerepository;
    IPatternRepo _patternrepository;
    IMaterialRepo _materialrepository;
    IColorRepo _colorrepository;
    IArmTypeRepo _armTyperepository;
    IClothGenderRepo _clothGenderrepository;
    IClothCategoryRepo _clothCategoryrepository;
    IDefaultPriceRepo _defaultPricerepository;
    IStaffRepo _staffrepository;
    ICustomerRepo _customerrepository;
    IEmailSend _email;
    public OrderService(IEmailSend email, IOrderRepo repository, IStyleRepo styleRepo, IPatternRepo patternRepo, IMaterialRepo materialRepo, IColorRepo colorRepo, IArmTypeRepo armTypeRepo, IClothCategoryRepo clothCategoryRepo, IClothGenderRepo clothGenderRepo, IDefaultPriceRepo defaultPricerepository, IStaffRepo staffrepository, ICustomerRepo customerrepository)
    {
        _repository = repository;
        _stylerepository = styleRepo;
        _patternrepository = patternRepo;
        _materialrepository = materialRepo;
        _colorrepository = colorRepo;
        _armTyperepository = armTypeRepo;
        _clothCategoryrepository = clothCategoryRepo;
        _clothGenderrepository = clothGenderRepo;
        _defaultPricerepository = defaultPricerepository;
        _staffrepository = staffrepository;
        _customerrepository = customerrepository;
        _email = email;
    }
    public async Task<BaseResponse> Create(CreateOrderDto createOrderDto)
    {
        var order = new Order()
        {
            OrderId = $"ORDER{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15).ToUpper()}",
            ArmTypeId = createOrderDto.ArmTypeId,
            ClothCategoryId = createOrderDto.ClothCategory,
            ClothGenderId = createOrderDto.ClothGenderId,
            ColorId = createOrderDto.ColorId,
            StyleId = createOrderDto.StyleId,
            PatternId = createOrderDto.PatternId,
            MaterialId = createOrderDto.MaterialId,
            Pieces = createOrderDto.Pieces,
            OrderPerson = createOrderDto.OrderPerson,
            CustomerId = createOrderDto.CustomerId,
            AddToCart = false,
            IsDeleted = false,
            LastModifiedOn = DateTime.UtcNow,
            OrderAddress = new OrderAddress()
            {
                PostalCode = createOrderDto.OrderAddress.PostalCode,
                Street = createOrderDto.OrderAddress.Street,
                City = createOrderDto.OrderAddress.City,
                Region = createOrderDto.OrderAddress.Region,
                State = createOrderDto.OrderAddress.State,
                Country = createOrderDto.OrderAddress.Country,
                IsDeleted = false,
            },
            OrderMeasurements = new OrderMeasurement()
            {
                AnkleSize = createOrderDto.CreateOrderMeasurementDto.AnkleSize.ToString(),
                ArmLength = createOrderDto.CreateOrderMeasurementDto.ArmLength.ToString(),
                ArmSize = createOrderDto.CreateOrderMeasurementDto.ArmSize.ToString(),
                BackWaist = createOrderDto.CreateOrderMeasurementDto.BackWaist.ToString(),
                BodyHeight = createOrderDto.CreateOrderMeasurementDto.BodyHeight.ToString(),
                BurstGirth = createOrderDto.CreateOrderMeasurementDto.BurstGirth.ToString(),
                FrontWaist = createOrderDto.CreateOrderMeasurementDto.FrontWaist.ToString(),
                Head = createOrderDto.CreateOrderMeasurementDto.Head.ToString(),
                HighHips = createOrderDto.CreateOrderMeasurementDto.HighHips.ToString(),
                HipSize = createOrderDto.CreateOrderMeasurementDto.HipSize.ToString(),
                LegLength = createOrderDto.CreateOrderMeasurementDto.LegLength.ToString(),
                NeckSize = createOrderDto.CreateOrderMeasurementDto.NeckSize.ToString(),
                ShoulderWidth = createOrderDto.CreateOrderMeasurementDto.ShoulderWidth.ToString(),
                ThirdQuarterLegLength = createOrderDto.CreateOrderMeasurementDto.ThirdQuarterLegLength.ToString(),
                WaistSize = createOrderDto.CreateOrderMeasurementDto.WaistSize.ToString(),
                WristCircumfrence = createOrderDto.CreateOrderMeasurementDto.WristCircumfrence.ToString(),
                IsDeleted = false,
            }
        };
        await _repository.Create(order);
        return new BaseResponse()
        {
            Message = "Order Created Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> Update(int id, UpdateOrderDto updateOrderDto)
    {
        var order = await _repository.GetOrderById(id);
        if(order != null)
        {
            order.ArmTypeId = updateOrderDto.ArmTypeId;
            order.ClothCategoryId = updateOrderDto.ClothCategory;
            order.ClothGenderId = updateOrderDto.ClothGenderId;
            order.ColorId = updateOrderDto.ColorId;
            order.StyleId = updateOrderDto.StyleId;
            order.PatternId = updateOrderDto.PatternId;
            order.MaterialId = updateOrderDto.MaterialId;
            order.Pieces = updateOrderDto.Pieces;
            order.OrderPerson = updateOrderDto.OrderPerson;
            order.OrderAddress.PostalCode = updateOrderDto.UpdateOrderAddressDto.PostalCode ?? order.OrderAddress.PostalCode;
            order.OrderAddress.Street = updateOrderDto.UpdateOrderAddressDto.Street ?? order.OrderAddress.Street;
            order.OrderAddress.City = updateOrderDto.UpdateOrderAddressDto.City ?? order.OrderAddress.City;
            order.OrderAddress.Region = updateOrderDto.UpdateOrderAddressDto.Region ?? order.OrderAddress.Region;
            order.OrderAddress.State = updateOrderDto.UpdateOrderAddressDto.State ?? order.OrderAddress.State;
            order.OrderAddress.Country = updateOrderDto.UpdateOrderAddressDto.Country ?? order.OrderAddress.Country;

            await _repository.Update(order);
            return new BaseResponse()
            {
                Message = "Order Updated Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Update Order Successfully",
            Status = false
        };
    }
    public async Task<BaseResponse> UpdatePayment(UpdateOrderPaymentCheck updateOrderPayment)
    {
        if (updateOrderPayment.Check == true)
        {
            var customer = await _customerrepository.GetById(updateOrderPayment.CustomerId);
            var cart = await GetCartOrdersByCustomerId(customer.Id);
            foreach (var order in cart.Data.GetOrderDtos)
            {
                var updateOrder = await _repository.GetOrderById(order.Id);
                updateOrder.IsPaid = IsPaid.Paid;
                updateOrder.AddToCart = false;
                updateOrder.ReferenceNumber = updateOrderPayment.ReferenceNo;
                await _repository.Update(updateOrder);
            }                 
            var email = new CreateEmailDto()
            {
                Subject = "Order(s) Completed Successfully",
                ReceiverName = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName}",
                ReceiverEmail = customer.User.Email,
                Message = $"Hi Thanks for shopping with us. /n" +
            $"Check your order history to keep track of your Orders /n" +
            $"{GetOrderNos(cart).ToString()} /n" + "Vee Tailoring"
            };
            await _email.SendEmail(email);
            var adminEmail = new CreateEmailDto()
            {
                Subject = "Order(s) Payment Completed Successfully",
                ReceiverName = $"Inioluwa Johansson",
                ReceiverEmail = "inioluwa.makinde10@gmail.com",
                Message = $"{customer.UserDetails.LastName} {customer.UserDetails.FirstName} shopped with Uu. /n" +
            $"You can use the following order numbers to keep track of the Orders /n" +
            $"{(GetOrderNos(cart))} /n" + "Vee Tailoring"
            };
            await _email.SendEmail(adminEmail);
            return new BaseResponse()
            {
                Message = "Payment Successful",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Payment Successful",
            Status = true
        };
    }
    public async Task<BaseResponse> AddRemoveFromCart(int id)
    {
        var order = await _repository.GetOrderById(id);
        if (order != null)
        {
            if (order.AddToCart == false && order.IsPaid == IsPaid.NotPaid)
            {
                order.AddToCart = true;
                await _repository.Update(order);
                return new BaseResponse()
                {
                    Message = "Order Added To Cart Successfully",
                    Status = true
                };
            }
            else if (order.AddToCart == true && order.IsPaid == IsPaid.NotPaid)
            {
                order.AddToCart = false;
                await _repository.Update(order);
                return new BaseResponse()
                {
                    Message = "Order Removed From Cart Successfully",
                    Status = true
                };
            }
        }
        return new BaseResponse()
        {
            Message = "Unable To Perform Action On Order Successfully",
            Status = false
        };
    }
    public async Task<OrderResponseModel> GetOrderById(int id)
    {
        var order = await _repository.GetOrderById(id);
        if(order != null)
        {
            var style = await _stylerepository.GetById(order.StyleId);
            var pattern = await _patternrepository.GetById(order.PatternId);
            var armType = await _armTyperepository.GetById(order.ArmTypeId);
            var color = await _colorrepository.GetById(order.ColorId);
            var material = await _materialrepository.GetById(order.MaterialId);
            var clothCategory = await _clothCategoryrepository.GetById(order.ClothCategoryId);
            var clothGender = await _clothGenderrepository.GetById(order.ClothGenderId);
            var customer = await _customerrepository.GetById(order.CustomerId);
            var staff = await _staffrepository.GetById(order.StaffId);
            var price = await _defaultPricerepository.GetDefaultPrice();
            return new OrderResponseModel()
            {
                Data = GetDetails(order, style, pattern, material, color, armType, clothCategory, clothGender,price, customer, staff),
                Message = "Order Retrieved Successfully",
                Status = true
            };
        }
        return new OrderResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Order Successfully",
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrderByCustomerUserIdOrderNo(int UserId, string OrderNo)
    {
        var Orders = await _repository.GetOrderbyCustomerIdOrderNo(UserId, OrderNo);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Order Successfully",
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrderByOrderNo(string OrderNo)
    {
        var Orders = await _repository.GetOrderbyOrderNo(OrderNo);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Order Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Order Successfully",
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetAllOrders()
    {
        var Orders = await _repository.ListAllOrders();
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetAllAssignedOrders()
    {
        var Orders = await _repository.ListAllAssignedOrders();
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetAllUnAssignedOrders()
    {
        var Orders = await _repository.ListAllUnAssignedOrders();
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetAllOrdersByIsCompleted(IsCompleted isCompleted)
    {
        var Orders = await _repository.ListAllOrdersByIsCompleted(isCompleted);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetAllOrdersByIsPaid(IsPaid isPaid)
    {
        var Orders = await _repository.ListAllOrdersByIsPaid(isPaid);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByCustomerId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByCustomerUserId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerUserId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<CartResponseModel> GetCartOrdersByCustomerId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerIdIsNotPaid(id);
        if (Orders.Where(c => c.AddToCart == true) != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            decimal totalOrderPrice = 0;
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                var Details = GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff);
                OrderList.Add(Details);
                totalOrderPrice += Details.Price;
            }
            var shippingFees = await _defaultPricerepository.GetShippingFees();
            var cartDto = new GetCartDto()
            {
                GetOrderDtos = OrderList,
                Price = shippingFees.Price,
                TotalPrice = totalOrderPrice + shippingFees.Price,
            };
            return new CartResponseModel()
            {
                Data = cartDto,
                Message = "Cart Retrieved Successfully",
                Status = true
            };
        }
        return new CartResponseModel()
        {
            Data = null,
            Message = "Cart Is Empty",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrderByCustomerIdIsPaid(int id, IsPaid IsPaid)
    {
        var Orders = await _repository.ListAllOrdersByCustomerIdIsPaid(id, IsPaid);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffId(int id)
    {
        var Orders = await _repository.ListAllOrdersByStaffId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffUserId(int id)
    {
        var Orders = await _repository.ListAllOrdersByStaffUserId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffIdIsCompleted(int id, IsCompleted IsCompleted)
    {
        var Orders = await _repository.ListAllOrdersByStaffIdIsCompleted(id, IsCompleted);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders)
            {
                var style = await _stylerepository.GetById(Order.StyleId);
                var pattern = await _patternrepository.GetById(Order.PatternId);
                var armType = await _armTyperepository.GetById(Order.ArmTypeId);
                var color = await _colorrepository.GetById(Order.ColorId);
                var material = await _materialrepository.GetById(Order.MaterialId);
                var clothCategory = await _clothCategoryrepository.GetById(Order.ClothCategoryId);
                var clothGender = await _clothGenderrepository.GetById(Order.ClothGenderId);
                var customer = await _customerrepository.GetById(Order.CustomerId);
                var staff = await _staffrepository.GetById(Order.StaffId);
                var price = await _defaultPricerepository.GetDefaultPrice();
                OrderList.Add(GetDetails(Order, style, pattern, material, color, armType, clothCategory, clothGender, price, customer, staff));
            }
            return new OrdersResponseModel()
            {
                Data = OrderList,
                Message = "Orders List Retrieved Successfully",
                Status = true
            };
        }
        return new OrdersResponseModel()
        {
            Data = null,
            Message = "Unable To Retrieve Orders List Successfully",
            Status = true
        };
    }
    public async Task<BaseResponse> AssignAnOrder(int id, int staffId, DateTime completionTime)
    {
        var order = await _repository.GetOrderById(id);
        var staff = await _staffrepository.GetByUserId(staffId);
        var list = await _repository.GetByExpression(c => c.StaffId == staff.Id && c.IsCompleted == IsCompleted.Pending);
        if (order != null && staff != null)
        {
            if (list.Count < 5)
            {
                order.StaffId = staff.Id;
                order.CompletionTime = completionTime;
                await _repository.Update(order);
                return new BaseResponse()
                {
                    Message = "Order Assigned To You Successfully",
                    Status = true
                };
            }
            return new BaseResponse()
            {
                Message = "You have 5 pending Orders. Complete them before taking on a new order",
                Status = false
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Assign An Order To You Successfully",
            Status = false
        };
    }
    public GetOrderDto GetDetails(Order order, Style style, Pattern pattern, Material material, Color color, ArmType armType, ClothCategory clothCategory, ClothGender clothGender, DefaultPrice defaultPrice, Customer customer, Staff staff)
    {
        decimal price = 0;
        string completionDate = "";
        if (order.IsPaid == IsPaid.Paid)
        {
            price = order.Price;
        }
        else
        {
            decimal measurementPrice = (Decimal.Parse(customer.Measurements.AnkleSize) + 
                Decimal.Parse(customer.Measurements.ArmLength) +
                Decimal.Parse(customer.Measurements.ArmSize) +
                Decimal.Parse(customer.Measurements.BackWaist) + 
                Decimal.Parse(customer.Measurements.BodyHeight) + 
                Decimal.Parse(customer.Measurements.BurstGirth) + 
                Decimal.Parse(customer.Measurements.FrontWaist) + 
                Decimal.Parse(customer.Measurements.Head) + 
                Decimal.Parse(customer.Measurements.HighHips) + 
                Decimal.Parse(customer.Measurements.HipSize) + 
                Decimal.Parse(customer.Measurements.LegLength) + 
                Decimal.Parse(customer.Measurements.NeckSize) + 
                Decimal.Parse(customer.Measurements.ShoulderWidth) + 
                Decimal.Parse(customer.Measurements.ThirdQuarterLegLength) + 
                Decimal.Parse(customer.Measurements.WaistSize) + 
                Decimal.Parse(customer.Measurements.WristCircumfrence)
                ) * defaultPrice.Price;
            price = (measurementPrice + style.StylePrice + pattern.PatternPrice + material.MaterialPrice) * order.Pieces;
        }
        if (order.CompletionTime.CompareTo(DateTime.Today) <= 0)
        {
            completionDate = "Order Completed";
        }
        else
        {
            completionDate = $"{(order.CompletionTime.CompareTo(DateTime.Today))} days left to completion.";
        }
        return new GetOrderDto()
        {
            Id = order.Id,
            OrderId = order.OrderId,
            OrderPerson = order.OrderPerson,
            Pieces = order.Pieces,
            Price = price,
            IsCompleted = order.IsCompleted,
            IsPaid = order.IsPaid,
            IsAssigned = order.IsAssigned,
            OtherDetails = order.OtherDetails,
            CompletionTime = completionDate,
            GetStyleDto = new GetStyleDto()
            {
                StyleId = style.StyleId,
                StyleName = style.StyleName,
                StyleUrl = style.StyleUrl,
                StylePrice = style.StylePrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = clothCategory.Id,
                    ClothName = clothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = clothGender.Id,
                    Gender = clothGender.Gender,
                }
            },
            GetPatternDto = new GetPatternDto()
            {
                Id = pattern.Id,
                PatternName = pattern.PatternName,
                PatternUrl = pattern.PatternUrl,
                PatternPrice = pattern.PatternPrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = clothCategory.Id,
                    ClothName = clothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = clothGender.Id,
                    Gender = clothGender.Gender,
                }
            },
            GetMaterialDto = new GetMaterialDto()
            {
                Id = material.Id,
                MaterialName = material.MaterialName,
                MaterialUrl = material.MaterialUrl,
                MaterialPrice = material.MaterialPrice,
            },
            GetColorDto = new GetColorDto()
            {
                Id = color.Id,
                ColorName = color.ColorName,
                ColorCode = color.ColorCode,
            },
            GetArmTypeDto = new GetArmTypeDto()
            {
                Id = armType.Id,
                ArmLength = armType.ArmLength
            },
            GetOrderAddressDto = new GetOrderAddressDto()
            {
                NumberLine = order.OrderAddress.NumberLine,
                Street = order.OrderAddress.Street,
                City = order.OrderAddress.City,
                Region = order.OrderAddress.Region,
                State = order.OrderAddress.State,
                Country = order.OrderAddress.Country,
            },
            GetOrderMeasurementDto = new GetOrderMeasurementDto()
            {
                Id = order.OrderMeasurements.Id,
                Head = decimal.Parse(order.OrderMeasurements.Head),
                NeckSize = decimal.Parse(order.OrderMeasurements.NeckSize),
                ShoulderWidth = decimal.Parse(order.OrderMeasurements.ShoulderWidth),
                BurstGirth = decimal.Parse(order.OrderMeasurements.BurstGirth),
                ArmLength = decimal.Parse(order.OrderMeasurements.ArmLength),
                ArmSize = decimal.Parse(order.OrderMeasurements.ArmSize),
                WristCircumfrence = decimal.Parse(order.OrderMeasurements.WristCircumfrence),
                AnkleSize = decimal.Parse(order.OrderMeasurements.AnkleSize),
                HipSize = decimal.Parse(order.OrderMeasurements.HipSize),
                LegLength = decimal.Parse(order.OrderMeasurements.LegLength),
                WaistSize = decimal.Parse(order.OrderMeasurements.WaistSize),
                BodyHeight = decimal.Parse(order.OrderMeasurements.BodyHeight),
                FrontWaist = decimal.Parse(order.OrderMeasurements.FrontWaist),
                BackWaist = decimal.Parse(order.OrderMeasurements.BackWaist),
                HighHips = decimal.Parse(order.OrderMeasurements.HighHips),
                ThirdQuarterLegLength = decimal.Parse(order.OrderMeasurements.ThirdQuarterLegLength),
            },
            GetCustomerDto = new GetCustomerDto()
            {
                Id = customer.Id,
                CustomerNo = customer.CustomerNo,
                Email = customer.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = customer.UserDetails.FirstName,
                    LastName = customer.UserDetails.LastName,
                    ImageUrl = customer.UserDetails.ImageUrl,
                    Gender = customer.UserDetails.Gender,
                    PhoneNumber = customer.UserDetails.PhoneNumber,
                    GetAddressDto = new GetAddressDto()
                    {
                        NumberLine = customer.UserDetails.Address.NumberLine,
                        Street = customer.UserDetails.Address.Street,
                        City = customer.UserDetails.Address.City,
                        Region = customer.UserDetails.Address.Region,
                        State = customer.UserDetails.Address.State,
                        Country = customer.UserDetails.Address.Country,
                    }
                },
                GetMeasurementDto = new GetMeasurementDto()
                {
                    AnkleSize = Decimal.Parse(customer.Measurements.AnkleSize),
                    ArmLength = Decimal.Parse(customer.Measurements.ArmLength),
                    ArmSize = Decimal.Parse(customer.Measurements.ArmSize),
                    BackWaist = Decimal.Parse(customer.Measurements.BackWaist),
                    BodyHeight = Decimal.Parse(customer.Measurements.BodyHeight),
                    BurstGirth = Decimal.Parse(customer.Measurements.BurstGirth),
                    FrontWaist = Decimal.Parse(customer.Measurements.FrontWaist),
                    Head = Decimal.Parse(customer.Measurements.Head),
                    HighHips = Decimal.Parse(customer.Measurements.HighHips),
                    HipSize = Decimal.Parse(customer.Measurements.HipSize),
                    LegLength = Decimal.Parse(customer.Measurements.LegLength),
                    NeckSize = Decimal.Parse(customer.Measurements.NeckSize),
                    ShoulderWidth = Decimal.Parse(customer.Measurements.ShoulderWidth),
                    ThirdQuarterLegLength = Decimal.Parse(customer.Measurements.ThirdQuarterLegLength),
                    WaistSize = Decimal.Parse(customer.Measurements.WaistSize),
                    WristCircumfrence = Decimal.Parse(customer.Measurements.WristCircumfrence),
                }
            },
            GetStaffDto = new GetStaffDto()
            {
                Id = staff.Id,
                StaffNo = staff.StaffNo,
                Email = staff.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = staff.UserDetails.FirstName,
                    LastName = staff.UserDetails.LastName,
                    ImageUrl = staff.UserDetails.ImageUrl,
                    Gender = staff.UserDetails.Gender,
                    PhoneNumber = staff.UserDetails.PhoneNumber,
                    GetAddressDto = new GetAddressDto()
                    {
                        NumberLine = staff.UserDetails.Address.NumberLine,
                        Street = staff.UserDetails.Address.Street,
                        City = staff.UserDetails.Address.City,
                        Region = staff.UserDetails.Address.Region,
                        State = staff.UserDetails.Address.State,
                        Country = staff.UserDetails.Address.Country,
                    }
                }
            }
        };
    }
    public string GetOrderNos(CartResponseModel cart)
    {
        foreach (var order in cart.Data.GetOrderDtos)
        {
            return $"{order.OrderId.Take(5)} /n";
        }
        return null;
    }
    public async Task<OrderDashboard> OrdersDashboard()
    {
        int Total = (await _repository.GetAll()).Count;
        int Completed = (await _repository.GetByExpression(x => x.IsCompleted == IsCompleted.Completed)).Count;
        int UnCompleted = (await _repository.GetByExpression(x => x.IsCompleted == IsCompleted.Pending)).Count;
        int Assigned = (await _repository.GetByExpression(x => x.IsAssigned == true)).Count;
        int UnAssigned = (await _repository.GetByExpression(x => x.IsAssigned == false)).Count;
        int Paid = (await _repository.GetByExpression(x => x.IsPaid == IsPaid.Paid)).Count;
        int UnPaid = (await _repository.GetByExpression(x => x.IsPaid == IsPaid.Pending || x.IsPaid == IsPaid.NotPaid)).Count;
        if (Total != 0)
        {
            return new OrderDashboard
            {
                Total = Total,
                Assigned = Assigned,
                UnAssigned = UnAssigned,
                Completed = Completed,
                UnCompleted = UnCompleted,
                Paid = Paid,
                UnPaid = UnPaid,
                Status = true,
            };
        }
        return new OrderDashboard
        {
            Message = "No Orders Yet!",
            Status = false,
        };
    }
    public async Task<BaseResponse> DeActivateOrder(int id)
    {
        var order = await _repository.GetOrderById(id);
        if (order != null)
        {
            order.IsDeleted = true;
            await _repository.Update(order);
            return new BaseResponse()
            {
                Message = "Order Removed Successfully",
                Status = true
            };
        }
        return new BaseResponse()
        {
            Message = "Unable To Remove Order Successfully",
            Status = false
        };
    }
}