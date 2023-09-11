import { createApp } from 'vue';
import App from './App.vue';
import Router from './router';
import './axios';

import GenericButton from './components/Buttons/GenericButton.vue';
import GenericSubmitButton from './components/Buttons/GenericSubmitButton.vue';

import GenericTextbox from './components/Textbox/GenericTextbox.vue';
import GenericTextboxPassword from './components/Textbox/GenericTextboxPassword.vue';

const app = createApp(App);

app.use(Router);

app.component("GenericButton", GenericButton);
app.component("GenericSubmitButton", GenericSubmitButton);
app.component("GenericTextbox", GenericTextbox);
app.component("GenericTextboxPassword", GenericTextboxPassword);

app.mount('#app');
