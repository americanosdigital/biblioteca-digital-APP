using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using biblioteca_digital_Application.Interfaces;
using biblioteca_digital_Application.DTOs;
using biblioteca_digital_DOMAIN.Entities;

namespace biblioteca_digital_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;
        private readonly ILogger<LivrosController> _logger;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var livros = await _livroService.ObterTodosAsync();
                return Ok(livros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os livros.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {                
                var livro = await _livroService.ObterPorIdAsync(id);
                if (livro == null) return NotFound("Livro não encontrado.");
                return Ok(livro);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter o livro por ID.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] LivroDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Os dados do livro são inválidos.");

                var livro = Livro.Criar(dto.Titulo, dto.Autor, dto.Ano, dto.Genero);
                
                await _livroService.CriarAsync(livro);
                return CreatedAtAction(nameof(ObterPorId), new { id = dto.Id }, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar o livro.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] LivroDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Os dados do livro são inválidos.");

                if (id != dto.Id)
                    return BadRequest("O ID do livro não corresponde ao ID fornecido.");
                
                var livroExistente = await _livroService.ObterPorIdAsync(id);
                if (livroExistente == null)
                    return NotFound("Livro não encontrado.");
                
                livroExistente.Atualizar(dto.Titulo, dto.Autor, dto.Ano, dto.Genero);

                await _livroService.AtualizarAsync(livroExistente);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o livro.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            try
            {
                await _livroService.RemoverAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir o livro.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a solicitação.");
            }
        }
    }

}
