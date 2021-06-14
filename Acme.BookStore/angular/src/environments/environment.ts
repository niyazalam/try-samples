import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'BookStore',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44316',
    redirectUri: baseUrl,
    clientId: 'BookStore_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone BookStore',
  },
  apis: {
    default: {
      url: 'https://localhost:44316',
      rootNamespace: 'Acme.BookStore',
    },
  },
} as Environment;
