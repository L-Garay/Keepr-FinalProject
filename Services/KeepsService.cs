using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    internal Keep GetById(int keepId, string userId)
    {
      var exists = _repo.GetById(keepId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      else if (exists.IsPrivate == true)
      {
        throw new Exception("You can't access this");
      }
      return exists;
    }

    internal IEnumerable<Keep> GetByUserId(string userId)
    {
      return _repo.GetByUserId(userId);
    }

    public Keep Create(Keep newKeep)
    {
      _repo.Create(newKeep);
      return newKeep;
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal Keep Edit(Keep update, string userId)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists.UserId != userId)
      {
        throw new Exception("You can't access that");
      }
      _repo.Edit(update);
      return update;
    }

    internal Keep EditKeepViews(Keep update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists != null)
      {
        update.Views++;
        _repo.Edit(update);
      }
      return update;
    }

    internal Keep EditKeepKeeps(Keep update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists != null)
      {
        update.Keeps++;
        _repo.Edit(update);
      }
      return update;
    }

    internal string Delete(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists.UserId != userId)
      {
        throw new Exception("You can't do that");
      }
      _repo.Delete(id);
      return "Successfully deleted..";
    }
  }
}