using courier.management.system.Models;
using courier.management.system.Services.Interface;

namespace courier.management.system.Services.Implementation
{
    public class SqlService : ISqlService
    {
        public string GetStadiums(bool isCount)
        {
            string start = @"SELECT ";
            string count = @"count (*) as totalCount";
            string variables = @" 
            s.name as name,
            s.code as code,
            st.name as type,
            cb.name as branch_name,
            s.min_price as min_price
            ";
            string main = @" 
            from stadium as s
            left join stadium_type as st 
            on st.id = s.type_id
            left join company_branch as cb 
            on cb.id = s.branch_id";

            string end = @" ORDER BY name OFFSET :skip ROWS FETCH NEXT :limit ROWS ONLY";

            if (isCount)
            {
                return start + count + main;
            }
            else
            {
                return start + variables + main + end;
            }
        }

    }
}
