using opg_201910_interview.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace opg_201910_interview.Service
{
    public interface IFileManagement
    {
        List<string> getFiles(Files files);

    }
}
