using Moq;
using NotesAppSqlServer.BusinessLayer.Interface;
using NotesAppSqlServer.BusinessLayer.Services;
using NotesAppSqlServer.BusinessLayer.Services.Repository;
using NotesAppSqlServer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotesAppSqlServer.Test.TestCases
{
    public class Boundary
    {
        private INoteService _services;
        public readonly Mock<INoteRepository> service = new Mock<INoteRepository>();
        static Boundary()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        public Boundary()
        {
            // TextFiles.CreateBoundaryTextfile();
            _services = new NoteService(service.Object);
        }
        Random random = new Random();


        [Fact]
        public async Task<bool> BoundaryTestfor_ValidateNotesId()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 36,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Id >= 35 && result.Id <= 350000)
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_ValidateNotesId=" + finalvalue + "\n");
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_ValidateNotesId", finalvalue);

            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateTitleEmptyString()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Title != "")
            {
                finalvalue = true;
            }
            else
                finalvalue = false;

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateTitleEmptyString=" + finalvalue + "\n");
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateTitleEmptyString", finalvalue);

            return finalvalue;
            //Assert.NotEmpty(result.Title);
            //Assert.NotEmpty(result.Author);
            //Assert.NotEmpty(result.Description);
            //Assert.NotEmpty(result.Status);
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateAuthorEmptyString()
        {
            bool finalvalue = false;

            //assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Author != "")
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }

            //finalresult displaying in text file
             File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateAuthorEmptyString=" + finalvalue + "\n");
           // TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateAuthorEmptyString", finalvalue);


            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateStatusEmptyString()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = "note",
                Description = "Note applicaction",
                Status = "done"
            };

            //Setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Status != "")
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }

            //finalresult displaying in text file
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateStatusEmptyString", finalvalue);

            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateStatusEmptyString=" + finalvalue + "\n");

            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateIdNotNull()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = null,
                Description = "Note applicaction",
                Status = "done"
            };

            //setup 
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Id != null)
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateIdNotNull", finalvalue);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateIdNotNull=" + finalvalue + "\n");


            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateAuthorNotNull()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = "lavanya",
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Author != null)
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }

            //finalresult displaying in text file
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateAuthorNotNull", finalvalue);
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateAuthorNotNull=" + finalvalue + "\n");

            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateDecriptionNotNull()
        {
            bool finalvalue = false;

            //assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = null,
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Description != null)
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }

            //finalresult displaying in text file
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateDecriptionNotNull", finalvalue);
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateDecriptionNotNull=" + finalvalue + "\n");

            return finalvalue;
        }
        [Fact]
        public async Task<bool> BoundaryTestfor_validateStatusNotNull()
        {
            bool finalvalue = false;

            //Assigning values
            var notes = new Note()
            {
                Id = 123,
                Title = "update",
                Author = null,
                Description = "Note applicaction",
                Status = "done"
            };

            //setup
            service.Setup(repo => repo.CreateAsync(notes)).ReturnsAsync(notes);
            var result = await _services.CreateAsync(notes);
            if (result.Status != null)
            {
                finalvalue = true;
            }
            else
            {
                finalvalue = false;
            }

            //finalresult displaying in text file
            //TextFiles.AppendTextAllBoundaryText("BoundaryTestfor_validateStatusNotNull", finalvalue);
            File.AppendAllText("../../../../output_boundary_revised.txt", "BoundaryTestfor_validateStatusNotNull=" + finalvalue + "\n");

            return finalvalue;
        }
    }
}
