using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
  public class ProgressData
  {
    [JsonProperty("pls")] public List<string> PassedLevels;
  }
}