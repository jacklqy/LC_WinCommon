# LC_WinCommon
WinForm通用类库封装

1.BaseDAL类之删除  ----DAL基类

    bool Delete(int delType, string strWhere, int isDeleted, SqlParameter[] paras)
    
    bool Delete(int id, int delType, int isDeleted)
    
    bool DeleteList(List<int> idList, int delType, int isDeleted)
    
    //关联表信息删除Sql生成（）
    List<string> GetDeleteSql(int delType, string strWhere, int isDeleted, string[] tables)
    
    List<string> GetDeleteSql(int delType, int Id, int isDeleted,string[] tables)
    
    List<string> GetDeleteListSql(int delType, List<int> Ids, int isDeleted, string[] tables)
    
2.BQuery类封装

    T GetModel(string strWhere, string strCols, params SqlParameter[] paras)
   
    T GetById(int id, string strCols)
   
    bool Exists(string strWhere, params SqlParameter[] paras)
   
    bool ExistsByName(string sName, string vName)
   
    bool ExistsByName(string sName, string vName, string sParent, int parId)
   
    List<T> GetModelList(string strWhere, string strCols, params SqlParameter[] paras)
   
    List<T> GetModelList(string cols,int IsDeleted)
   
    List<S> GetRowsModelList<S>(string strWhere, string cols,string rowName,string orderbyCol, params SqlParameter[] paras)
   
    List<S> GetRowsModelList<S>(string cols, int IsDeleted, string rowName)
   
    PageModel<S> GetRowsModelList<S>(string strWhere,string cols, int startIndex,int pageSize, params SqlParameter[] paras)

    DataTable GetList(string sql, int isProc,  params SqlParameter[] paras)
   
    DataSet GetDs(string sql, int isProc, params SqlParameter[] paras)

实表： 添加   修改  删除（真、逻辑） 查询（单个、范围、全部、部分   条件）
   
视图（添加、修改、删除 不能）、   查询

BaseDAL (增、删、改、》 查----- BQuery(查询基类)

BaseDAL （增删改）  BQuery (查询)

分页：Record   总数据条数    PageList 当页的数据列表   
   
分页控件：当前页   开始索引   每页显示条数    PageChanged   

三个特性  AttributeHelper   PropertyHelper   CreateSql  DbConvert BaseDAL  BQuery   SqlHelper  CommandInfo   SqlModel   PageModel

BLL  组合层   砌成墙     
DAL  砖块层  一块一块的砖   sql   列名    参数定义  
