import { ControleDeCustosPage } from './app.po';

describe('controle-de-custos App', () => {
  let page: ControleDeCustosPage;

  beforeEach(() => {
    page = new ControleDeCustosPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
