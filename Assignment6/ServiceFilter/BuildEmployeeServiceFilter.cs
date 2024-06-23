using Assignmentfifth.DTO;
using Assignmentfifth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filter;

namespace Assignmentfifth.ServiceFilter
{
    public class BuildEmployeeFilter : IAsyncActionFilter
    {
        public async Task OnActionExcecutionAsync(ActionExecutingContext,ActionExecutionDelegrate next)
        {
            var param = context.ActionArgument.SingleOrDefault(p =>p.Value is EmployeeFilterCriteria);
            if(param.Value != null) {
                context.Result = new BadRequestObjectResult("Object is null");
                return;

        }
            EmployeeFilterCriteria filterCriteria = (EmployeeFilterCriteria)param.Value;
            var statusFilter = filterCriteria.Filters.Find(a => a.FieldName = "status");
            if (statusFilter == null)
            {
                statusFilter = new FilterCriteria();
                statusFilter.FieldName = "Status";
                statusFilter.FieldValue = "Active";
                filterCriteria.Filters.add(statusFilter);
            }
            filterCriteria.Filters.removeAll(a => string.IsNullOrEmpty(a.FieldName));
            var result = await next();
    }
}