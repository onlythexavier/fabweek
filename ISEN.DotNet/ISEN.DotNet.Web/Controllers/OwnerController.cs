using System;
using ChartJSCore.Models;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ISEN.DotNet.Library.Repositories.Implementations;

namespace ISEN.DotNet.Web.Controllers
{
    public class OwnerController : BaseController<IOwnerRepository, Owner>
    {
        public IStatementRepository StatementRepository;
        public IEquipmentRepository EquipmentRepository;

        public OwnerController(IOwnerRepository repository, ILogger<BaseController<IOwnerRepository, Owner>> logger,
            UserManager<AccountUser> userManager, IStatementRepository statementRepository, IEquipmentRepository equipmentRepository) : base(repository, logger,
            userManager)
        {
            StatementRepository = statementRepository;
            EquipmentRepository = equipmentRepository;
        }

        public IActionResult MyEquipment()
        {
            var accountUserId = ViewData["Id"] = UserManager.GetUserId(User);
            var userOwner = Repository.Single(p => p.Account.Id == (int) accountUserId);
            return View(userOwner);
        }

        public IActionResult MyStatement()
        {
            var accountUserId = ViewData["Id"] = UserManager.GetUserId(User);
            var userOwner = Repository.Single(p => p.Account.Id == (int) accountUserId);
            #region linechart
            Chart chart1 = new Chart {Type = "line"};

            Data data1 = new Data {Labels = new List<string>()};
            LineDataset dataset1P = new LineDataset()
            {
                Label = "Production",
                Data = new List<double>(),
                Fill = false,
                LineTension = 0.1,
                BackgroundColor = "rgba(52, 201, 36, 0.4)",
                BorderColor = "rgba(52, 201, 36,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int>(),
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() {"rgba(52, 201, 36,1)"},
                PointBackgroundColor = new List<string>() {"#fff"},
                PointBorderWidth = new List<int> {1},
                PointHoverRadius = new List<int> {5},
                PointHoverBackgroundColor = new List<string>() {"rgba(52, 201, 36,1)"},
                PointHoverBorderColor = new List<string>() {"rgba(52, 201, 36,1)"},
                PointHoverBorderWidth = new List<int> {2},
                PointRadius = new List<int> {1},
                PointHitRadius = new List<int> {10},
                SpanGaps = false
            };
            LineDataset dataset1C = new LineDataset()
            {
                Label = "Consommation",
                Data = new List<double>(),
                Fill = false,
                LineTension = 0.1,
                BackgroundColor = "rgba(187, 11, 11, 0.4)",
                BorderColor = "rgba(187, 11, 11,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int>(),
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() {"rgba(187, 11, 11,1)"},
                PointBackgroundColor = new List<string>() {"#fff"},
                PointBorderWidth = new List<int> {1},
                PointHoverRadius = new List<int> {5},
                PointHoverBackgroundColor = new List<string>() {"rgba(187, 11, 11,1)"},
                PointHoverBorderColor = new List<string>() {"rgba(187, 11, 11,1)"},
                PointHoverBorderWidth = new List<int> {2},
                PointRadius = new List<int> {1},
                PointHitRadius = new List<int> {10},
                SpanGaps = false
            };
            var statements1 = StatementRepository.Find(p => p.Equipment.Owner.Id == userOwner.Id).OrderBy(p => p.Date).GroupBy(p => p.Date);
            foreach (var statement in statements1)
            {
                var prod = 0.0;
                foreach (var state in statement)
                {
                    prod += state.Production;
                    dataset1C.Data.Add(state.Consommation);
                    data1.Labels.Add(state.Date.ToUniversalTime().ToString());
                }
                foreach (var state in statement)
                {
                    dataset1P.Data.Add(prod);
                }
            }

            data1.Datasets = new List<Dataset> {dataset1P, dataset1C};

            chart1.Data = data1;

            ViewData["chart1"] = chart1;
            #endregion
            #region barchart
            Chart chart2 = new Chart { Type = "bar" };

            Data data2 = new Data { Labels = new List<string>() };
            LineDataset dataset2P = new LineDataset()
            {
                Label = "Production",
                Data = new List<double>(),
                Fill = false,
                LineTension = 0.1,
                BackgroundColor = "rgba(52, 201, 36, 0.4)",
                BorderColor = "rgba(52, 201, 36,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int>(),
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() { "rgba(52, 201, 36,1)" },
                PointBackgroundColor = new List<string>() { "#fff" },
                PointBorderWidth = new List<int> { 1 },
                PointHoverRadius = new List<int> { 5 },
                PointHoverBackgroundColor = new List<string>() { "rgba(52, 201, 36,1)" },
                PointHoverBorderColor = new List<string>() { "rgba(52, 201, 36,1)" },
                PointHoverBorderWidth = new List<int> { 2 },
                PointRadius = new List<int> { 1 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };
            LineDataset dataset2C = new LineDataset()
            {
                Label = "Consommation",
                Data = new List<double>(),
                Fill = false,
                LineTension = 0.1,
                BackgroundColor = "rgba(187, 11, 11, 0.4)",
                BorderColor = "rgba(187, 11, 11,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int>(),
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() { "rgba(187, 11, 11,1)" },
                PointBackgroundColor = new List<string>() { "#fff" },
                PointBorderWidth = new List<int> { 1 },
                PointHoverRadius = new List<int> { 5 },
                PointHoverBackgroundColor = new List<string>() { "rgba(187, 11, 11,1)" },
                PointHoverBorderColor = new List<string>() { "rgba(187, 11, 11,1)" },
                PointHoverBorderWidth = new List<int> { 2 },
                PointRadius = new List<int> { 1 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };
            var statements2 = StatementRepository.Find(p => p.Equipment.Owner.Id == userOwner.Id).OrderBy(p => p.Date);
            foreach (var statement in statements2)
            {
                data2.Labels.Add(statement.Date.ToUniversalTime().ToString());
                dataset2P.Data.Add(statement.Production);
                dataset2C.Data.Add(statement.Consommation);
            }

            data2.Datasets = new List<Dataset> { dataset2P, dataset2C };

            chart2.Data = data2;

            ViewData["chart2"] = chart2;
            #endregion
            #region piechart
            Chart chart3 = new Chart { Type = "polarArea" };

            Data data3 = new Data { Labels = new List<string>() };
            PolarDataset dataset3 = new PolarDataset()
            {
                Label = "My Production",
                BackgroundColor = new List<string>(),
                Data = new List<double>()
            };

            var green = 0;
            var statements3 = EquipmentRepository.Find(p => p.Owner.Id == userOwner.Id);
            foreach (var statement in statements3)
            {
                data3.Labels.Add(statement.Name);
                var somme = 0.0;
                var tests = StatementRepository.Find(p => p.Equipment.Owner.Id == userOwner.Id &&
                                                         p.Equipment == statement);
                foreach (var test in tests)
                {
                    somme += test.Production;
                }
                dataset3.BackgroundColor.Add("rgba("+green+", 137, 35, 0.6)");
                green += 50;
                dataset3.Data.Add(somme);
            }
            
            data3.Datasets = new List<Dataset> { dataset3 };

            chart3.Data = data3;

            ViewData["chart3"] = chart3;
            #endregion
            return View(userOwner);
        }
    }
}