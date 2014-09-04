﻿using CurioExchange.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CurioExchange.ViewModels;
using CurioExchange.Models;

namespace CurioExchange.Controllers
{
    public class UserPiecesController : Controller
    {
        private IPieceAgent _pieceAgent;

        public UserPiecesController(IPieceAgent pieceAgent)
        {
            _pieceAgent = pieceAgent;
        }

        // GET: UserPiece
        public async Task<ActionResult> Index()
        {
            var model = new UserPieceViewModel();
            var userPieces = await _pieceAgent.RetrieveUserPieces(User.Identity.GetUserId());
            model.WantedPieces.AddRange(userPieces.Where(t => t.Owned == false));
            model.OwnedPieces.AddRange(userPieces.Where(t => t.Owned));
            return View(model);
        }

        // GET: UserPiece/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserPiece/Create
        public async Task<ActionResult> CreateWanted()
        {
            var model = new UserPieceModel
            {
                Pieces = await _pieceAgent.RetrievePieces(),
                User_Id = User.Identity.GetUserId()
            };
            model.Pieces = model.Pieces.OrderBy(t => t.Name).ToList();
            return View(model);
        }

        public async Task<ActionResult> CreateOwned()
        {
            var model = new UserPieceModel
            {
                Owned = true,
                Pieces = await _pieceAgent.RetrievePieces(),
                User_Id = User.Identity.GetUserId()
            };
            model.Pieces = model.Pieces.OrderBy(t => t.Name).ToList();
            return View(model);
        }

        // POST: UserPiece/Create
        [HttpPost]
        public async Task<ActionResult> CreateWanted(UserPieceModel model)
        {
            try
            {
                await _pieceAgent.CreaseUserPiece(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateOwned(UserPieceModel model)
        {
            try
            {
                await _pieceAgent.CreaseUserPiece(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UserPiece/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserPiece/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserPiece/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _pieceAgent.DeleteUserPiece(id);
            return RedirectToAction("Index");
        }
    }
}