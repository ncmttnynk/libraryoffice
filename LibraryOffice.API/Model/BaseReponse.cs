using System;
using System.Collections.Generic;

public class BaseResponse<T> {
  public T Data { get; set; }
  public ICollection<T> List { get; set; }
  public Boolean isSuccess { get; set; }
}