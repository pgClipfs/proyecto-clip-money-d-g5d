export class Result<T> {
    public Object: T;
    public Ok: boolean;
    public Errors: Array<string>;
    public ErrorsText: string;
}