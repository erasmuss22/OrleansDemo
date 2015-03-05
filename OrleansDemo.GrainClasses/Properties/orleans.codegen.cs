//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace OrleansDemo.GrainClasses
{
    using Orleans.CodeGeneration;
    using Orleans;
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.Collections;
    using OrleansDemo.GrainInterfaces;
    using Orleans.Runtime;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("OrleansDemo.GrainClasses.OrleansDemo.GrainClasses.PostalOrderGrain")]
    public class PostalOrderGrainState : global::Orleans.CodeGeneration.GrainState, IPostalOrderState
    {
        

            public String @Name { get; set; }

            public ITruck @Truck { get; set; }

            public String @Status { get; set; }

            public Int32 @Cost { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("Name", out value)) @Name = (String) value;
                if (values.TryGetValue("Truck", out value)) @Truck = (ITruck) value;
                if (values.TryGetValue("Status", out value)) @Status = (String) value;
                if (values.TryGetValue("Cost", out value)) @Cost = value is Int64 ? (Int32)(Int64)value : (Int32)value;
            }

            public override System.String ToString()
            {
                return System.String.Format("PostalOrderGrainState( Name={0} Truck={1} Status={2} Cost={3} )", @Name, @Truck, @Status, @Cost);
            }
        
        public PostalOrderGrainState() : 
                base("OrleansDemo.GrainClasses.PostalOrderGrain")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["Name"] = this.Name;
            result["Truck"] = this.Truck;
            result["Status"] = this.Status;
            result["Cost"] = this.Cost;
            return result;
        }
        
        private void InitStateFields()
        {
            this.Name = default(String);
            this.Truck = default(ITruck);
            this.Status = default(String);
            this.Cost = default(Int32);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            PostalOrderGrainState input = ((PostalOrderGrainState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            PostalOrderGrainState input = ((PostalOrderGrainState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            PostalOrderGrainState result = new PostalOrderGrainState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("OrleansDemo.GrainClasses.OrleansDemo.GrainClasses.TruckGrain")]
    public class TruckGrainState : global::Orleans.CodeGeneration.GrainState, ITruckState
    {
        

            public String @Location { get; set; }

            public IEnumerable<IPostalOrder> @PostalOrders { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("Location", out value)) @Location = (String) value;
                if (values.TryGetValue("PostalOrders", out value)) @PostalOrders = (IEnumerable<IPostalOrder>) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("TruckGrainState( Location={0} PostalOrders={1} )", @Location, @PostalOrders);
            }
        
        public TruckGrainState() : 
                base("OrleansDemo.GrainClasses.TruckGrain")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["Location"] = this.Location;
            result["PostalOrders"] = this.PostalOrders;
            return result;
        }
        
        private void InitStateFields()
        {
            this.Location = default(String);
            this.PostalOrders = default(IEnumerable<IPostalOrder>);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            TruckGrainState input = ((TruckGrainState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            TruckGrainState input = ((TruckGrainState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            TruckGrainState result = new TruckGrainState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif