namespace ApiBox.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using ApiBox.Constants;
    using ApiBox.Repositories;
    using ApiBox.ViewModels;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Mvc;

    public class PostCarCommand : IPostCarCommand
    {
        private readonly ICarRepository carRepository;
        private readonly IMapper<Models.Car, Car> carToCarMapper;
        private readonly IMapper<SaveCar, Models.Car> saveCarToCarMapper;

        public PostCarCommand(
            ICarRepository carRepository,
            IMapper<Models.Car, Car> carToCarMapper,
            IMapper<SaveCar, Models.Car> saveCarToCarMapper)
        {
            this.carRepository = carRepository;
            this.carToCarMapper = carToCarMapper;
            this.saveCarToCarMapper = saveCarToCarMapper;
        }

        public async Task<IActionResult> ExecuteAsync(SaveCar saveCar, CancellationToken cancellationToken)
        {
            var car = this.saveCarToCarMapper.Map(saveCar);
            car = await this.carRepository.Add(car, cancellationToken);
            var carViewModel = this.carToCarMapper.Map(car);

            return new CreatedAtRouteResult(
                CarsControllerRoute.GetCar,
                new { carId = carViewModel.CarId },
                carViewModel);
        }
    }
}