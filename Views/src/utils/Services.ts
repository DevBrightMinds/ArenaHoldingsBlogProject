import { Environment } from "./Environment";

export class MainServices {
    AppData: any;
    MainUrl: string;

    constructor() {
        this.AppData = Environment;
        this.MainUrl = this.AppData.URLs.MainUrl;
    }

    GetArticles = async (): Promise<any> => {
        return fetch(`${this.MainUrl + this.AppData.EndPoints.GetArticles}`, {
            method: "GET",
            headers: {
                "Accept": "*",
                "Content-Type": "application/json"
            },
        })
            .then((response: any) => response.json())
    }

    SubscribeUser = async (params: any): Promise<any> => {
        return fetch(`${this.MainUrl + this.AppData.EndPoints.SubscribeUser}`, {
            method: "POST",
            headers: {
                "Accept": "*",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(params)
        })
            .then((response: any) => response.json())
    }
}
