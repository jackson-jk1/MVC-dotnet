﻿using CursoApi.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CursoTeste
{
    public class CategoriasControllerTeste
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;
        public CategoriasControllerTeste()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { id = 1, Descricao = "TATAKAE" };

            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);


            _mockContext.Setup(m => m.Categorias.FindAsync(1)).ReturnsAsync(_categoria);
        }

        [Fact]
        public async Task Get_Categoria()
            {
                var service = new CategoriasController(_mockContext.Object);

                await service.GetCategoria(1);

                _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            }
        

      
    }
}
