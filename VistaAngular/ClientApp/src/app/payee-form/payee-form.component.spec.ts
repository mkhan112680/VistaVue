/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PayeeFormComponent } from './payee-form.component';

let component: PayeeFormComponent;
let fixture: ComponentFixture<PayeeFormComponent>;

describe('payee-form component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ PayeeFormComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(PayeeFormComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});