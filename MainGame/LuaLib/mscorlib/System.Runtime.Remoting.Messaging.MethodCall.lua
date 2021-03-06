---@class System.Runtime.Remoting.Messaging.MethodCall : System.Object
---@field public ArgCount number
---@field public Args any[]
---@field public HasVarArgs boolean
---@field public InArgCount number
---@field public InArgs any[]
---@field public LogicalCallContext System.Runtime.Remoting.Messaging.LogicalCallContext
---@field public MethodBase System.Reflection.MethodBase
---@field public MethodName string
---@field public MethodSignature any
---@field public Properties System.Collections.IDictionary
---@field public TypeName string
---@field public Uri string
local m = {}

---@virtual
---@param info System.Runtime.Serialization.SerializationInfo
---@param context System.Runtime.Serialization.StreamingContext
function m:GetObjectData(info, context) end

---@virtual
---@param argNum number
---@return any
function m:GetArg(argNum) end

---@virtual
---@param index number
---@return string
function m:GetArgName(index) end

---@virtual
---@param argNum number
---@return any
function m:GetInArg(argNum) end

---@virtual
---@param index number
---@return string
function m:GetInArgName(index) end

---@virtual
---@param h System.Runtime.Remoting.Messaging.Header[]
---@return any
function m:HeaderHandler(h) end

---@virtual
function m:Init() end

function m:ResolveMethod() end

---@virtual
---@param info System.Runtime.Serialization.SerializationInfo
---@param ctx System.Runtime.Serialization.StreamingContext
function m:RootSetObjectData(info, ctx) end

System.Runtime.Remoting.Messaging.MethodCall = m
return m
