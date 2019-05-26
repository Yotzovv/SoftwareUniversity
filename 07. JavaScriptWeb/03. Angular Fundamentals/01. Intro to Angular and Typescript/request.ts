export default class RequestData {
    private method: string;
    private uri: string;
    private version: string;
    private message: any;
    private response: string | undefined = undefined;
    private fulfilled: boolean = false;

    constructor(method: string, uri: string, version: string, message: string) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
    }
}