namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]

    public class AuthorQueryTypeExtension : ObjectTypeExtension {
        //protected override void Configure(IObjectTypeDescriptor descriptor) {
        //    descriptor.Name("Query");
        //    descriptor.Field("Authors")
        //        .ResolveWith<AuthorResolver>(resolver => resolver.Authors(default)).UseProjection();

        //    descriptor.Field("AuthorById")
        //        .ResolveWith<AuthorResolver>(resolver => resolver.AuthorById(default, default))
        //        .UseProjection();

        //    //descriptor.Field(t => t.Authors(default)).UseProjection();
        //    //descriptor.Field(t => t.AuthorById(default, default)).UseProjection();
        //}
    }
}
