using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.Acceso
{
    public class UsuarioUnitTest
    {
        private readonly Mock<UsuarioRepository> _repository;
        private readonly AccesoServices _service;

        public UsuarioUnitTest()
        {
            _repository = new Mock<UsuarioRepository>();
            _service = new AccesoServices(_repository.Object, null, null, null);
        }


        
    }
}
