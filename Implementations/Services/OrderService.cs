using Vee_Tailoring.Emails;
using Vee_Tailoring.Entities;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Models.DTOs;
using Vee_Tailoring.Models.Enums;
using System.Runtime.InteropServices;

namespace Vee_Tailoring.Implementations.Services;

public class OrderService : IOrderService
{
    IOrderRepo _repository;
    IDefaultPriceRepo _defaultPricerepository;
    IStaffRepo _staffrepository;
    ICustomerRepo _customerrepository;
    public OrderService(IOrderRepo repository, IDefaultPriceRepo defaultPricerepository, IStaffRepo staffrepository, ICustomerRepo customerrepository)
    {
        _repository = repository;
        _defaultPricerepository = defaultPricerepository;
        _staffrepository = staffrepository;
        _customerrepository = customerrepository;
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
            order.OrderMeasurements.AnkleSize = $"{updateOrderDto.UpdateOrderMeasurementDto.AnkleSize}" ?? order.OrderMeasurements.AnkleSize;
            order.OrderMeasurements.ArmLength = $"{updateOrderDto.UpdateOrderMeasurementDto.ArmLength}" ?? order.OrderMeasurements.ArmLength;
            order.OrderMeasurements.ArmSize = $"{updateOrderDto.UpdateOrderMeasurementDto.ArmSize}" ?? order.OrderMeasurements.ArmSize;
            order.OrderMeasurements.BackWaist = $"{updateOrderDto.UpdateOrderMeasurementDto.BackWaist}" ?? order.OrderMeasurements.BackWaist;
            order.OrderMeasurements.BodyHeight = $"{updateOrderDto.UpdateOrderMeasurementDto.BodyHeight}" ?? order.OrderMeasurements.BodyHeight;
            order.OrderMeasurements.BurstGirth = $"{updateOrderDto.UpdateOrderMeasurementDto.BurstGirth}" ?? order.OrderMeasurements.BurstGirth;
            order.OrderMeasurements.FrontWaist = $"{updateOrderDto.UpdateOrderMeasurementDto.FrontWaist}" ?? order.OrderMeasurements.FrontWaist;
            order.OrderMeasurements.Head = $"{updateOrderDto.UpdateOrderMeasurementDto.Head}" ?? order.OrderMeasurements.Head;
            order.OrderMeasurements.HighHips = $"{updateOrderDto.UpdateOrderMeasurementDto.HighHips}" ?? order.OrderMeasurements.HighHips;
            order.OrderMeasurements.HipSize = $"{updateOrderDto.UpdateOrderMeasurementDto.HipSize}" ?? order.OrderMeasurements.HipSize;
            order.OrderMeasurements.LegLength = $"{updateOrderDto.UpdateOrderMeasurementDto.LegLength}" ?? order.OrderMeasurements.LegLength;
            order.OrderMeasurements.NeckSize = $"{updateOrderDto.UpdateOrderMeasurementDto.NeckSize}" ?? order.OrderMeasurements.NeckSize;
            order.OrderMeasurements.ShoulderWidth = $"{updateOrderDto.UpdateOrderMeasurementDto.ShoulderWidth}" ?? order.OrderMeasurements.ShoulderWidth;
            order.OrderMeasurements.ThirdQuarterLegLength = $"{updateOrderDto.UpdateOrderMeasurementDto.ThirdQuarterLegLength}" ?? order.OrderMeasurements.ThirdQuarterLegLength;
            order.OrderMeasurements.WaistSize = $"{updateOrderDto.UpdateOrderMeasurementDto.WaistSize}" ?? order.OrderMeasurements.WaistSize;
            order.OrderMeasurements.WristCircumfrence = $"{updateOrderDto.UpdateOrderMeasurementDto.WristCircumfrence}" ?? order.OrderMeasurements.WristCircumfrence;
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
    public async Task<bool> UpdatePayment(UpdateOrderPaymentCheck updateOrderPayment)
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
            return true;
        }
        return false;
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
            return new OrderResponseModel()
            {
                Data = await GetDetails(order),
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
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetAllAssignedOrders()
    {
        var Orders = await _repository.ListAllAssignedOrders();
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetAllUnAssignedOrders()
    {
        var Orders = await _repository.ListAllUnAssignedOrders();
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetAllOrdersByIsCompleted(IsCompleted isCompleted)
    {
        var Orders = await _repository.ListAllOrdersByIsCompleted(isCompleted);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetAllOrdersByIsPaid(IsPaid isPaid)
    {
        var Orders = await _repository.ListAllOrdersByIsPaid(isPaid);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByCustomerId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByCustomerUserId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerUserId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<CartResponseModel> GetCartOrdersByCustomerId(int id)
    {
        var Orders = await _repository.ListAllOrdersByCustomerIdIsPaid(id, IsPaid.NotPaid);
        if (Orders.Where(c => c.AddToCart == true) != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            decimal totalOrderPrice = 0;
            foreach (var Order in Orders)   OrderList.Add(await GetDetails(Order));
            foreach (var Order in OrderList)    totalOrderPrice += Order.Price;
            var cartDto = new GetCartDto()
            {
                GetOrderDtos = OrderList,
                TotalPrice = totalOrderPrice,
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrderByCustomerIdIsPaid(int id, IsPaid IsPaid)
    {
        var Orders = await _repository.ListAllOrdersByCustomerIdIsPaid(id, IsPaid);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrderByCustomerUserIdDate(int id, DateTime startdate, DateTime endDate)
    {
        var Orders = await _repository.ListAllOrdersByCustomerUserIdDate(id, startdate, endDate);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffId(int id)
    {
        var Orders = await _repository.ListAllOrdersByStaffId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffUserId(int id)
    {
        var Orders = await _repository.ListAllOrdersByStaffUserId(id);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
        };
    }
    public async Task<OrdersResponseModel> GetOrdersByStaffIdIsCompleted(int id, IsCompleted IsCompleted)
    {
        var Orders = await _repository.ListAllOrdersByStaffIdIsCompleted(id, IsCompleted);
        if (Orders != null)
        {
            List<GetOrderDto> OrderList = new List<GetOrderDto>();
            foreach (var Order in Orders) OrderList.Add(await GetDetails(Order));
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
            Status = false
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
    public async Task<GetOrderDto> GetDetails(Order order)
    {
        decimal price = 0;
        string completionDate = "";
        var defaultPrice = await _defaultPricerepository.GetDefaultPrice();
        if (order.IsPaid == IsPaid.Paid)
        {
            price = order.Price;
        }
        else
        {
            decimal measurementPrice = (Decimal.Parse(order.OrderMeasurements.AnkleSize) + 
                Decimal.Parse(order.OrderMeasurements.ArmLength) +
                Decimal.Parse(order.OrderMeasurements.ArmSize) +
                Decimal.Parse(order.OrderMeasurements.BackWaist) + 
                Decimal.Parse(order.OrderMeasurements.BodyHeight) + 
                Decimal.Parse(order.OrderMeasurements.BurstGirth) + 
                Decimal.Parse(order.OrderMeasurements.FrontWaist) + 
                Decimal.Parse(order.OrderMeasurements.Head) + 
                Decimal.Parse(order.OrderMeasurements.HighHips) + 
                Decimal.Parse(order.OrderMeasurements.HipSize) + 
                Decimal.Parse(order.OrderMeasurements.LegLength) + 
                Decimal.Parse(order.OrderMeasurements.NeckSize) + 
                Decimal.Parse(order.OrderMeasurements.ShoulderWidth) + 
                Decimal.Parse(order.OrderMeasurements.ThirdQuarterLegLength) + 
                Decimal.Parse(order.OrderMeasurements.WaistSize) + 
                Decimal.Parse(order.OrderMeasurements.WristCircumfrence)
                ) * defaultPrice.Price;
            price = (measurementPrice + order.Style.StylePrice + order.Pattern.PatternPrice + order.Material.MaterialPrice) * order.Pieces;
        }
        if (order.CompletionTime.CompareTo(DateTime.Today) <= 0 && order.IsPaid == IsPaid.Paid)
        {
            completionDate = "Order Completed";
        }
        else if (order.IsPaid == IsPaid.NotPaid)
        {
            completionDate = "NaN";
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
                StyleId = order.Style.StyleId,
                StyleName = order.Style.StyleName,
                StyleUrl = order.Style.StyleUrl,
                StylePrice = order.Style.StylePrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = order.ClothCategory.Id,
                    ClothName = order.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = order.ClothGender.Id,
                    Gender = order.ClothGender.Gender,
                }
            },
            GetPatternDto = new GetPatternDto()
            {
                Id = order.Pattern.Id,
                PatternName = order.Pattern.PatternName,
                PatternUrl = order.Pattern.PatternUrl,
                PatternPrice = order.Pattern.PatternPrice,
                GetClothCategoryDto = new GetClothCategoryDto()
                {
                    Id = order.ClothCategory.Id,
                    ClothName = order.ClothCategory.ClothName
                },
                GetClothGenderDto = new GetClothGenderDto()
                {
                    Id = order.ClothGender.Id,
                    Gender = order.ClothGender.Gender,
                }
            },
            GetMaterialDto = new GetMaterialDto()
            {
                Id = order.Material.Id,
                MaterialName = order.Material.MaterialName,
                MaterialUrl = order.Material.MaterialUrl,
                MaterialPrice = order.Material.MaterialPrice,
            },
            GetColorDto = new GetColorDto()
            {
                Id = order.Color.Id,
                ColorName = order.Color.ColorName,
                ColorCode = order.Color.ColorCode,
            },
            GetArmTypeDto = new GetArmTypeDto()
            {
                Id = order.ArmType.Id,
                ArmLength = order.ArmType.ArmLength
            },
            GetOrderAddressDto = new GetOrderAddressDto()
            {
                NumberLine = order.OrderAddress.NumberLine,
                Street = order.OrderAddress.Street,
                City = order.OrderAddress.City,
                Region = order.OrderAddress.Region,
                State = order.OrderAddress.State,
                Country = order.OrderAddress.Country,
                PostalCode = order.OrderAddress.PostalCode,
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
                Id = order.Customer.Id,
                CustomerNo = order.Customer.CustomerNo,
                Email = order.Customer.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = order.Customer.UserDetails.FirstName,
                    LastName = order.Customer.UserDetails.LastName,
                    ImageUrl = order.Customer.UserDetails.ImageUrl,
                    Gender = order.Customer.UserDetails.Gender,
                    PhoneNumber = order.Customer.UserDetails.PhoneNumber,
                    GetAddressDto = new GetAddressDto()
                    {
                        NumberLine = order.Customer.UserDetails.Address.NumberLine,
                        Street = order.Customer.UserDetails.Address.Street,
                        City = order.Customer.UserDetails.Address.City,
                        Region = order.Customer.UserDetails.Address.Region,
                        State = order.Customer.UserDetails.Address.State,
                        Country = order.Customer.UserDetails.Address.Country,
                    }
                },
                GetMeasurementDto = new GetMeasurementDto()
                {
                    AnkleSize = Decimal.Parse(order.Customer.Measurements.AnkleSize),
                    ArmLength = Decimal.Parse(order.Customer.Measurements.ArmLength),
                    ArmSize = Decimal.Parse(order.Customer.Measurements.ArmSize),
                    BackWaist = Decimal.Parse(order.Customer.Measurements.BackWaist),
                    BodyHeight = Decimal.Parse(order.Customer.Measurements.BodyHeight),
                    BurstGirth = Decimal.Parse(order.Customer.Measurements.BurstGirth),
                    FrontWaist = Decimal.Parse(order.Customer.Measurements.FrontWaist),
                    Head = Decimal.Parse(order.Customer.Measurements.Head),
                    HighHips = Decimal.Parse(order.Customer.Measurements.HighHips),
                    HipSize = Decimal.Parse(order.Customer.Measurements.HipSize),
                    LegLength = Decimal.Parse(order.Customer.Measurements.LegLength),
                    NeckSize = Decimal.Parse(order.Customer.Measurements.NeckSize),
                    ShoulderWidth = Decimal.Parse(order.Customer.Measurements.ShoulderWidth),
                    ThirdQuarterLegLength = Decimal.Parse(order.Customer.Measurements.ThirdQuarterLegLength),
                    WaistSize = Decimal.Parse(order.Customer.Measurements.WaistSize),
                    WristCircumfrence = Decimal.Parse(order.Customer.Measurements.WristCircumfrence),
                }
            },
            GetStaffDto = new GetStaffDto()
            {
                Id = order.Staff.Id,
                StaffNo = order.Staff.StaffNo,
                Email = order.Staff.User.Email,
                GetUserDetailsDto = new GetUserDetailsDto()
                {
                    FirstName = order.Staff.UserDetails.FirstName,
                    LastName = order.Staff.UserDetails.LastName,
                    ImageUrl = order.Staff.UserDetails.ImageUrl,
                    Gender = order.Staff.UserDetails.Gender,
                    PhoneNumber = order.Staff.UserDetails.PhoneNumber,
                    GetAddressDto = new GetAddressDto()
                    {
                        NumberLine = order.Staff.UserDetails.Address.NumberLine,
                        Street = order.Staff.UserDetails.Address.Street,
                        City = order.Staff.UserDetails.Address.City,
                        Region = order.Staff.UserDetails.Address.Region,
                        State = order.Staff.UserDetails.Address.State,
                        Country = order.Staff.UserDetails.Address.Country,
                        PostalCode = order.Staff.UserDetails.Address.PostalCode,
                    }
                }
            }
        };
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