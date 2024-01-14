﻿namespace codecord_api
{
  public abstract class Base
  {
    public int Id { get; }
    public DateTime CreatedAt { get; set;}
    public DateTime UpdatedAt { get; set;}
    public bool IsDeleted { get; set; }
  }
}
