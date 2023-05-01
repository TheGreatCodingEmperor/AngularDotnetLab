import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent {

    menuMode = 'static';

    constructor(
        private primengConfig: PrimeNGConfig,
        private http:HttpClient
        ) { }

    ngOnInit() {
        this.primengConfig.ripple = true;
        document.documentElement.style.fontSize = '14px';
        this.http.get('/api/WeatherForecast').subscribe(res => {
            console.log(res);
        });
    }
}
